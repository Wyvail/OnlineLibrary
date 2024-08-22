import { useState } from "react";


function DeleteBookForm() {
    // state variables for email and passwords
    const [delTitle, setDelTitle] = useState("");

    // state variable for error messages
    const [error, setDelError] = useState("");

    // handle change events for input fields
    const handleDelChange = (e) => {
        const { name, value } = e.target;
        if (name === "title") setDelTitle(value);

    }
        // console.log("email: " + email + " password: " + password + " confirmPassword: " + confirmPassword + "librarian status " + librarian);
        ;

    // handle submit event for the form
    const handleSubmit = (e) => {
        e.preventDefault();
        // validate email and passwords
        if (!delTitle) {
            setDelError("Please fill in all fields.");
        } else {
            // clear error message
            setDelError("");
            // post data to the /register api
            fetch("/api/Books?title=" + delTitle, {
                method: "DELETE",
                headers: {
                    "Content-Type": "application/json",
                }
            })
                //.then((response) => response.json())
                .then((data) => {
                    // handle success or error from the server
                    console.log(data);
                    if (data.ok)
                        setDelError("Successful deletion.");
                    else
                        setDelError("Error deleting book.");

                })
                .catch((error) => {
                    // handle network error
                    console.error(error);
                    setDelError("Error deleting book.");
                });

        };
    }
    return (
        <div className="containerbox">
            <h3>Delete a book:</h3>

            <form onSubmit={handleSubmit}>
                <div>
                    <label htmlFor="title">Title:</label>
                </div><div>
                    <input
                        type="title"
                        id="title"
                        name="title"
                        value={delTitle}
                        onChange={handleDelChange}
                    />
                </div>
                <div>
                    <button type="submit">Delete Book</button>

                </div>

            </form>

            {error && <p className="error">{error}</p>}
        </div>
    );
}

export default DeleteBookForm;