/* eslint-disable react/prop-types */
import React from 'react';
import '../App.css';
import AddBookForm from './AddBookForm.jsx';
import UpdateBookForm from './UpdateBookForm.jsx';
import DeleteBookForm from './DeleteBookForm.jsx';

export default class BookHandler extends React.Component {

    constructor(props) {
        super(props);
        this._isMounted = false;

        this.state = {
            loading: true,
            books: [],
            currentIndex: 0,
            expanded: false,
            librarian: false,
            checkedOut: false,
            returned: false,
            sortedField: null,
            sortDirection: "asc",
            firstSort: true,
            currentFocus: "",
            currentInput: "",
        };
        //this.contents = books === undefined

    }

    componentDidMount() {
        console.log("BookTable mounted");
        this._isMounted = true;
        this._isMounted && this.populateBookData();
        this._isMounted && this.getLibrarianStatus();
    }

    componentWillUnmount() {
        this._isMounted = false;
    }

    async handleSort(field) {

        if (this.state.sortDirection === "asc" && !this.state.firstSort) this.setState({ sortDirection: "desc" });
        else this.setState({ sortDirection: "asc" });
        if (this.state.firstSort) this.setState({ firstSort: false });
        this.setState({ sortedField: field, expanded: false });
        this.setState({
            books: this.state.books.sort((a, b) => {
                if (a[field] < b[field]) {
                    return this.state.sortDirection === "asc" ? -1 : 1;
                }
                if (a[field] > b[field]) {
                    return this.state.sortDirection === "asc" ? 1 : -1;
                }
            })
        });
        await this.forceUpdate();
    }

    handleClick(index) {
        this.setState({ checkedOut: false });
        if (!this.state.expanded) {
            this.setState({ expanded: !this.state.expanded, currentIndex: index });
        }
        else if (index == this.state.currentIndex) {
            this.setState({ expanded: !this.state.expanded });
        }
        else {
            this.setState({ currentIndex: index });
        }

    }

    calculateReturnDate(year, month, date) {
        if (month == 2) {
            //February case
            if (date + 5 > 28) {
                date = date + 5 - 28;
                month = 3;
            }
            else {
                date = date + 5;
            }
        }
        else if (month == 4 || month == 6 || month == 9 || month == 11) {
            if (date + 5 > 30) {
                date = date + 5 - 30;
                month = month + 1;
            }
            else {
                date = date + 5;
            }

        }
        else if (month == 12) {
            //December case
            if (date + 5 > 31) {
                date = date + 5 - 31;
                month = 1;
                year = year + 1;
            }
            else {
                date = date + 5;
            }
        }
        else {
            if (date + 5 > 31) {
                date = date + 5 - 31;
                month = month + 1;
            }
            else {
                date = date + 5;
            }
        }
        var newDate = year + '-' + month + '-' + date;
        return newDate
    }

    async handleCheckout(title) {
        var currentDate = new Date();
        //console.log(currentDate);
        var year = currentDate.getFullYear();
        var month = currentDate.getMonth();
        var date = currentDate.getDate();
        var checkoutDate = year + '-' + month + '-' + date;
        //console.log(formattedDate);
        var returnDate = this.calculateReturnDate(year, month, date);
        //var encodedTitle = encodeURI(title);

        try {
            await fetch('/api/Books/updateBookAvailability?title=' + title, {
                method: 'PUT',
                headers: {
                    "Content-Type": "application/json",
                    'Accept': 'application/json'
                },
                body: JSON.stringify({
                    available: false,
                    checkOutDate: checkoutDate,
                    returnDate: returnDate
                }),
            })
                .then((response) => response.json())
                .then((data) => {
                    console.log(data)
                });
        }
        catch (error) {
            console.error('Failed to checkout book:', error);
        }

        this.setState({ expanded: false, checkedOut: true });
        await this.populateBookData();
        await this.forceUpdate();
    }

    async handleReturn(title) {
        try {
            await fetch('/api/Books/updateBookAvailability?title=' + title, {
                method: 'PUT',
                headers: {
                    "Content-Type": "application/json",
                    'Accept': 'application/json'
                },
                body: JSON.stringify({
                    available: true,
                    checkOutDate: "checkoutDate",
                    returnDate: "returnDate"
                }),
            })
                .then((response) => response.json())
                .then((data) => {
                    console.log(data)
                });
        }
        catch (error) {
            console.error('Failed to return book:', error);
        }

        this.setState({ expanded: false, returned: true });
        await this.populateBookData();
        await this.forceUpdate();
    }

    render() {
        return (
            <div>
                <h1>Welcome to the library!</h1>
                <p>Click on a row to view extra details about that book.</p>
                {this.state.expanded
                    ?
                    <div>
                        <p className="expanded">{this.state.books[this.state.currentIndex].publisher}</p>
                        <p className="expanded">{this.state.books[this.state.currentIndex].publishDate}</p>
                        <p className="expanded">{this.state.books[this.state.currentIndex].isbn}</p>
                        <p className="expanded">{this.state.books[this.state.currentIndex].category}</p>
                        <p className="expanded">{this.state.books[this.state.currentIndex].pageCount}</p>
                        {this.state.books[this.state.currentIndex].available ?
                            <button className="checkout-button" onClick={() => this.handleCheckout(this.state.books[this.state.currentIndex].title)}>Check out</button>
                            : <p>Not available, return date: {this.state.books[this.state.currentIndex].returnDate}</p>

                        }
                        {this.state.librarian && !this.state.books[this.state.currentIndex].available ?
                            <button className="return-button" onClick={() => this.handleReturn(this.state.books[this.state.currentIndex].title)}>Mark as Returned</button>
                            : (null)
                        }
                    </div>
                    : (null)
                }
                {this.state.checkedOut ? <p>Book checked out!</p> : (null)}
                {this.state.returned ? <p>Book returned!</p> : (null)}
                <button onClick={() => { this.populateBookData(); this.setState({ expanded: false }) }}>Refresh</button>
                <input type="text" className="form-control" id="titleSearch" onKeyUp={() => { this.searchListings(); }} onClick={() => this.setState({ currentInput: "titleSearch", currentFocus: "title" })}
                    placeholder="Search Titles" aria-label="Search" aria-describedby="basic-addon1" />
                <input type="text" className="form-control" id="authorSearch" onKeyUp={() => { this.searchListings(); }} onClick={() => this.setState({ currentInput: "authorSearch", currentFocus: "author" })}
                    placeholder="Search Authors" aria-label="Search" aria-describedby="basic-addon1" />
                <input type="text" className="form-control" id="availSearch" onKeyUp={() => { this.searchListings(); }} onClick={() => this.setState({ currentInput: "availSearch", currentFocus: "available" })}
                    placeholder="Search Availability" aria-label="Search" aria-describedby="basic-addon1" />
                <table className="table table-striped" aria-labelledby="tableLabel">
                    <thead>
                        <tr>
                            <th>
                                <button type="button" onClick={() => this.handleSort("title")}>
                                    Title {this.state.sortedField === "title" ? this.state.sortDirection === "asc" ? "Desc" : "Asc" : (null)}
                                </button>
                            </th>
                            <th>
                                <button type="button" onClick={() => this.handleSort("author")}>
                                    Author {this.state.sortedField === "author" ? this.state.sortDirection === "asc" ? "Desc" : "Asc" : (null)}
                                </button>
                            </th>
                            <th>Description</th>
                            <th>Cover</th>
                            <th>
                                <button type="button" onClick={() => this.handleSort("available")}>
                                    Availability {this.state.sortedField === "available" ? this.state.sortDirection === "asc" ? "Yes" : "No" : (null)}
                                </button>
                            </th>
                        </tr>
                    </thead>
                    <tbody>
                        {this.state.loading ? (null) : this.state.books.map((book, index) =>
                            <tr key={"Book " + index} onClick={() => this.handleClick(index)} className="bookRow">
                                <td className="title">{book.title}</td>
                                <td className="author">{book.author}</td>
                                <td>{book.description}</td>
                                <td>{book.imageId}</td>
                                <td className="available">{book.available ? <p>Available</p> : <p>Checked Out</p>}</td>
                            </tr>
                        )}
                    </tbody>
                </table>
                {this.state.librarian ?
                    <div>
                        <div>
                            <AddBookForm />
                        </div>
                        <div>
                            <UpdateBookForm />
                        </div>
                        <div>
                            <DeleteBookForm />
                        </div>
                    </div>
                    : (null)
                }


            </div>
        );
    }
    async populateBookData() {
        try {
            fetch('/api/books', {
                method: 'GET',
            })
                .then((response) => response.json())
                .then((data) => {

                    this.setState({ books: data, loading: false });
                    console.log(this.state.books)
                });
        }
        catch (error) {
            console.error('Failed to fetch weather data:', error);
        }
    }

    async getLibrarianStatus() {
        try {
            fetch('/api/librarianstatus?' + new URLSearchParams({
                email: this.props.currentUser.email,
            }).toString(), {
                method: 'GET',
            })
                .then((response) => response.json())
                .then((data) => {
                    console.log(data)
                    this.setState({ librarian: data });
                    console.log(this.state.librarian);
                });
        }
        catch (error) {
            console.error('Failed to get librarian status:', error);
        }
    }

    searchListings() {
        // Declare variables
        var input, filter, focus, listings, p, i, txtValue;
        input = document.getElementById(this.state.currentInput);
        filter = input.value.toUpperCase();
        listings = document.getElementsByClassName("bookRow");
        focus = this.state.currentFocus;
        console.log(listings);

        // Loop through all list items, and hide those who don't match the search query
        for (i = 0; i < listings.length; i++) {
            p = listings[i].getElementsByClassName(focus)[0];
            txtValue = p.textContent || p.innerText;
            if (txtValue.toUpperCase().indexOf(filter) > -1) {
                listings[i].style.display = "";
            } else {
                listings[i].style.display = "none";
            }
            // Reposition footer as needed based on element removal/addition
        }
    }
}
