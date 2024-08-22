import { useState } from "react";


function AddBookForm() {
    // state variables for email and passwords
    const [title, setTitle] = useState("");
    const [author, setAuthor] = useState("");
    const [description, setDescription] = useState("");
    const [imageId, setImageId] = useState(0);
    const [publisher, setPublisher] = useState("");
    const [publishedDate, setPublishedDate] = useState(""); 
    const [category, setCategory] = useState("");
    const [isbn, setIsbn] = useState("");
    const [pageCount, setPageCount] = useState(0);
    //const [available, setAvailable] = useState(false);
    //const [checkoutDate, setCheckoutDate] = useState("");
    //const [returnDate, setReturnDate] = useState("");

    // state variable for error messages
    const [error, setError] = useState("");

    // handle change events for input fields
    const handleChange = (e) => {
        const { name, value } = e.target;
        if (name === "title") setTitle(value);
        if (name === "author") setAuthor(value);
        if (name === "description") setDescription(value);
        if (name === "imageId") setImageId(parseInt(value));
        if (name === "publisher") setPublisher(value);
        if (name === "publishedDate") setPublishedDate(value);
        if (name === "category") setCategory(value);
        if (name === "isbn") setIsbn(parseInt(value));
        if (name === "pageCount") setPageCount(parseInt(value));
        //if (name === "available") setAvailable(value);
        //if (name === "checkoutDate") setCheckoutDate(value);
        //if (name === "returnDate") setReturnDate(value);
        
        }
        // console.log("email: " + email + " password: " + password + " confirmPassword: " + confirmPassword + "librarian status " + librarian);
    ;

    // handle submit event for the form
    const handleSubmit = (e) => {
        e.preventDefault();
        // validate email and passwords
        if (!title || !author|| !description) {
            setError("Please fill in all fields.");
        } else {
            // clear error message
            setError("");
            // post data to the /register api
            fetch("/api/Books?title=" + title, {
                method: "POST",
                headers: {
                    "Content-Type": "application/json",
                },
                body: JSON.stringify({
                    title: title,
                    author: author,
                    description: description,
                    imageId: imageId,
                    publisher: publisher,
                    publishDate: publishedDate,
                    category: category,
                    isbn: isbn,
                    pageCount: pageCount,
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
                        setError("Successful addition.");
                    else
                        setError("Error adding book.");

                })
                .catch((error) => {
                    // handle network error
                    console.error(error);
                    setError("Error adding book.");
                });
          
        };
    }
    return (
        <div className="containerbox">
            <h3>Add a new book:</h3>

            <form onSubmit={handleSubmit}>
                <div>
                    <label htmlFor="title">Title:</label>
                </div><div>
                    <input
                        type="title"
                        id="title"
                        name="title"
                        value={title}
                        onChange={handleChange}
                    />
                </div>
                <div>
                    <label htmlFor="author">Author:</label></div><div>
                    <input
                        type="author"
                        id="author"
                        name="author"
                        value={author}
                        onChange={handleChange}
                    />
                </div>
                <div>
                    <label htmlFor="description">Description:</label></div><div>
                    <input
                        type="description"
                        id="description"
                        name="description"
                        value={description}
                        onChange={handleChange}
                    />
                </div>
                <div>
                    <label htmlFor="imageId">Cover:</label></div><div>
                    <input
                        type="imageId"
                        id="imageId"
                        name="imageId"
                        value={imageId}
                        onChange={handleChange}
                    />
                </div>
                <div>
                    <label htmlFor="publisher">Publisher:</label></div><div>
                    <input
                        type="publisher"
                        id="publisher"
                        name="publisher"
                        value={publisher}
                        onChange={handleChange}
                        />
                </div>
                <div>
                    <label htmlFor="publishedDate">Published Date:</label></div><div>
                    <input
                        type="publishedDate"
                        id="publishedDate"
                        name="publishedDate"
                        value={publishedDate}
                        onChange={handleChange}
                    />
                </div>
                <div>
                    <label htmlFor="category">Category:</label></div><div>
                    <input
                        type="category"
                        id="category"
                        name="category"
                        value={category}
                        onChange={handleChange}
                        />
                </div>
                <div>
                    <label htmlFor="isbn">ISBN:</label></div><div>
                    <input
                        type="isbn"
                        id="isbn"
                        name="isbn"
                        value={isbn}
                        onChange={handleChange}
                    />
                </div>
                <div>
                    <label htmlFor="pageCount">Page Count:</label></div><div>
                    <input
                        type="pageCount"
                        id="pageCount"
                        name="pageCount"
                        value={pageCount}
                        onChange={handleChange}
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

export default AddBookForm;