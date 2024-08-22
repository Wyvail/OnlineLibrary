import { useState } from "react";


function UpdateBookForm() {
    // state variables for email and passwords
    const [updTitle, setUpdTitle] = useState("");
    const [updAuthor, setUpdAuthor] = useState("");
    const [updDescription, setUpdDescription] = useState("");
    const [updImageId, setUpdImageId] = useState(0);
    const [updPublisher, setUpdPublisher] = useState("");
    const [updPublishedDate, setUpdPublishedDate] = useState("");
    const [updCategory, setUpdCategory] = useState("");
    const [updIsbn, setUpdIsbn] = useState("");
    const [updPageCount, setUpdPageCount] = useState(0);
    //const [available, setUpdAvailable] = useState(false);
    //const [checkoutDate, setUpdCheckoutDate] = useState("");
    //const [returnDate, setUpdReturnDate] = useState("");

    // state variable for error messages
    const [error, setUpdError] = useState("");

    // handle change events for input fields
    const handleUpdChange = (e) => {
        const { name, value } = e.target;
        if (name === "title") setUpdTitle(value);
        if (name === "author") setUpdAuthor(value);
        if (name === "description") setUpdDescription(value);
        if (name === "imageId") setUpdImageId(value);
        if (name === "publisher") setUpdPublisher(value);
        if (name === "publishedDate") setUpdPublishedDate(value);
        if (name === "category") setUpdCategory(value);
        if (name === "isbn") setUpdIsbn(value);
        if (name === "pageCount") setUpdPageCount(value);
        //if (name === "available") setUpdAvailable(value);
        //if (name === "checkoutDate") setUpdCheckoutDate(value);
        //if (name === "returnDate") setUpdReturnDate(value);

    }
        // console.log("email: " + email + " password: " + password + " confirmPassword: " + confirmPassword + "librarian status " + librarian);
        ;

    // handle submit event for the form
    const handleSubmit = (e) => {
        e.preventDefault();
        // validate email and passwords
        if (!updTitle || !updAuthor || !updDescription) {
            setUpdError("Please fill in all fields.");
        } else {
            // clear error message
            setUpdError("");
            // post data to the /register api
            fetch("/api/Books?title=" + updTitle, {
                method: "PUT",
                headers: {
                    "Content-Type": "application/json",
                },
                body: JSON.stringify({
                    title: updTitle,
                    author: updAuthor,
                    description: updDescription,
                    imageId: updImageId,
                    publisher: updPublisher,
                    publishDate: updPublishedDate,
                    category: updCategory,
                    isbn: updIsbn,
                    pageCount: updPageCount,
                    available: true,
                    checkOutDate: "checkoutDate",
                    returnDate: "returnDate"
                }),
            })
                //.then((response) => response.json())
                .then((data) => {
                    // handle success or error from the server
                    console.log(data);
                    if (data.ok)
                        setUpdError("Successful update.");
                    else
                        setUpdError("Error updating book.");

                })
                .catch((error) => {
                    // handle network error
                    console.error(error);
                    setUpdError("Error upating book.");
                });

        };
    }
    return (
        <div className="containerbox">
            <h3>Update a book:</h3>

            <form onSubmit={handleSubmit}>
                <div>
                    <label htmlFor="title">Title:</label>
                </div><div>
                    <input
                        type="title"
                        id="title"
                        name="title"
                        value={updTitle}
                        onChange={handleUpdChange}
                    />
                </div>
                <div>
                    <label htmlFor="author">Author:</label></div><div>
                    <input
                        type="author"
                        id="author"
                        name="author"
                        value={updAuthor}
                        onChange={handleUpdChange}
                    />
                </div>
                <div>
                    <label htmlFor="description">Description:</label></div><div>
                    <input
                        type="description"
                        id="description"
                        name="description"
                        value={updDescription}
                        onChange={handleUpdChange}
                    />
                </div>
                <div>
                    <label htmlFor="imageId">Cover:</label></div><div>
                    <input
                        type="imageId"
                        id="imageId"
                        name="imageId"
                        value={updImageId}
                        onChange={handleUpdChange}
                    />
                </div>
                <div>
                    <label htmlFor="publisher">Publisher:</label></div><div>
                    <input
                        type="publisher"
                        id="publisher"
                        name="publisher"
                        value={updPublisher}
                        onChange={handleUpdChange}
                    />
                </div>
                <div>
                    <label htmlFor="publishedDate">Published Date:</label></div><div>
                    <input
                        type="publishedDate"
                        id="publishedDate"
                        name="publishedDate"
                        value={updPublishedDate}
                        onChange={handleUpdChange}
                    />
                </div>
                <div>
                    <label htmlFor="category">Category:</label></div><div>
                    <input
                        type="category"
                        id="category"
                        name="category"
                        value={updCategory}
                        onChange={handleUpdChange}
                    />
                </div>
                <div>
                    <label htmlFor="isbn">ISBN:</label></div><div>
                    <input
                        type="isbn"
                        id="isbn"
                        name="isbn"
                        value={updIsbn}
                        onChange={handleUpdChange}
                    />
                </div>
                <div>
                    <label htmlFor="pageCount">Page Count:</label></div><div>
                    <input
                        type="pageCount"
                        id="pageCount"
                        name="pageCount"
                        value={updPageCount}
                        onChange={handleUpdChange}
                    />

                </div>

                <div>
                    <button type="submit">Register</button>

                </div>

            </form>

            {error && <p className="error">{error}</p>}
        </div>
    );
}

export default UpdateBookForm;