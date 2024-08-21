import { AuthorizedUser } from "./AuthorizeView.jsx";
import { useNavigate } from "react-router-dom";

function LogoutLink() {

    const navigate = useNavigate();

    const handleSubmit = (e) => {
        e.preventDefault();
        fetch("/logout", {
            method: "POST",
            headers: {
                "Content-Type": "application/json",
            },
            body: ""

        })
            .then((data) => {
                if (data.ok) {

                    navigate("/loginpage");
                }
                else {
                    console.log("Error logging out.")
                }


            })
            .catch((error) => {
                console.error(error);
            })

    };

    return (
        <>
            <a href="#" onClick={handleSubmit}>Logout <AuthorizedUser value="email" /></a>
        </>
    );
}

export default LogoutLink;