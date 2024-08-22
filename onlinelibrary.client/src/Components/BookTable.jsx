/* eslint-disable react/prop-types */
//unused
function BookTable(props) {
    const { books } = props.BooksToSort;
    return (
        <table className="table table-striped" aria-labelledby="tableLabel">
            <thead>
                <tr>
                    <th>Title</th>
                    <th>Author</th>
                    <th>Description</th>
                    <th>Cover</th>
                    <th>Availability</th>
                </tr>
            </thead>
            <tbody>
                {books.map((book, index) =>
                    <tr key={"Book " + index} onClick={props.passToParent(index)}>
                        <td>{book.title}</td>
                        <td>{book.author}</td>
                        <td>{book.description}</td>
                        <td>{book.imageId}</td>
                        <td>{book.available ? <p>Yes</p> : <p>No</p>}</td>
                    </tr>
                )}
            </tbody>
        </table>
    );
}

export default BookTable;