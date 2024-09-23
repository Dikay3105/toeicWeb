import { useState } from "react";
import { Link, useNavigate } from "react-router-dom";
import { AiFillEye, AiFillEyeInvisible } from 'react-icons/ai'; // Importing icons from react-icons
import { postRegister } from "../../../service/authService";
import { toast } from "react-toastify";

const Register = () => {
    const [email, setEmail] = useState("");
    const [password, setPassword] = useState("");
    const [confirmPassword, setConfirmPassword] = useState("");
    const [username, setUsername] = useState("");
    const [showPassword, setShowPassword] = useState(false);
    const navigate = useNavigate();

    const togglePasswordVisibility = () => {
        setShowPassword(!showPassword);
    };

    const validateConfirmPassword = () => {
        if (password === confirmPassword)
            return true;
        else return false;
    }

    const validateEmail = (email) => {
        return String(email)
            .toLowerCase()
            .match(
                /^(([^<>()[\]\\.,;:\s@"]+(\.[^<>()[\]\\.,;:\s@"]+)*)|.(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/
            );
    };

    const handleRegister = async () => {
        if (!validateEmail(email)) {
            toast.error("Invalid email");
            return
        }
        if (!validateConfirmPassword()) {
            toast.error("Password confirmation does not match");
            return
        }

        let response = await postRegister(email, username, password);
        if (response && response.EC === 0) {
            toast.success("Signup success");
            setTimeout(() => {
                navigate("/login", { state: { newEmail: email, newPassword: password } });
            }, 3000);
        } else if (response && response.EC !== 0) {
            toast.error(response.EM);
        }
    };

    return (
        <>
            <div className="login-container mt-3 d-grid gap-2">
                <div className="title fs-1 fw-bold col-4 mx-auto text-center">
                    Typeform
                </div>
                <div className="welcome col-4 mx-auto text-center">
                    Hello, let's start a new adventure!
                </div>
                <div className="content-form col-3 mx-auto d-grid gap-3">
                    <div className="form-group d-grid gap-2">
                        <label>Email</label>
                        <input
                            type="email"
                            className="form-control"
                            placeholder="bruce@wayne.com"
                            onChange={(event) => { setEmail(event.target.value) }}
                        />
                    </div>
                    <div className="form-group d-grid gap-2">
                        <label>Username</label>
                        <input
                            type="text"
                            className="form-control"
                            placeholder="brucewayne"
                            onChange={(event) => { setUsername(event.target.value) }}
                        />
                    </div>
                    <div className="form-group d-grid gap-2">
                        <label>Password</label>
                        <div className="input-group">
                            <input
                                type={showPassword ? "text" : "password"}
                                className="form-control"
                                placeholder="At least 8 characters"
                                onChange={(event) => { setPassword(event.target.value) }}
                            />
                            <button
                                type="button"
                                className="btn btn-outline-secondary"
                                onClick={togglePasswordVisibility}
                                style={{ borderLeft: 'none' }}
                            >
                                {showPassword ? <AiFillEyeInvisible /> : <AiFillEye />}
                            </button>
                        </div>
                    </div>

                    <div className="form-group d-grid gap-2">
                        <label>Confirm password</label>
                        <div className="input-group">
                            <input
                                type={showPassword ? "text" : "password"}
                                className="form-control"
                                placeholder=""
                                onChange={(event) => { setConfirmPassword(event.target.value) }}
                            />
                            <button
                                type="button"
                                className="btn btn-outline-secondary"
                                onClick={togglePasswordVisibility}
                                style={{ borderLeft: 'none' }}
                            >
                                {showPassword ? <AiFillEyeInvisible /> : <AiFillEye />}
                            </button>
                        </div>
                    </div>
                    <button className="btn btn-dark w-100" onClick={() => { handleRegister() }}> Sign up</button>
                    <div className="d-flex align-items-center">
                        <hr className="w-100" />
                        <span className="px-2">OR</span>
                        <hr className="w-100" />
                    </div>
                    <button className="btn btn-outline-dark w-100 d-flex align-items-center justify-content-center">
                        <img src="google-logo-url" alt="Google" className="me-2" />
                        Sign in with Google
                    </button>
                    <button className="btn btn-outline-dark w-100 d-flex align-items-center justify-content-center">
                        <img src="microsoft-logo-url" alt="Microsoft" className="me-2" />
                        Sign in with Microsoft
                    </button>
                    <a href="" onClick={() => navigate("/login")} className="text-center link-secondary mt-2">Return to login page</a>
                    <a href="" onClick={() => navigate("/")} className="text-center link-secondary mt-2">Go to homepage</a>
                </div>
            </div>

        </>
    );
}

export default Register;
