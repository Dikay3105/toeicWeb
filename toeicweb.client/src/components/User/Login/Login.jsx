import { useState } from "react";
import { postLogin } from "../../../services/authService";
const Login = () => {
    const [username, setUsername] = useState("");
    const [password, setPassword] = useState("");
    const [showPassword, setShowPassword] = useState(false);

    // Toggle password visibility
    const togglePasswordVisibility = () => {
        setShowPassword(!showPassword);
    };

    const handleLogin = async () => {
        if (!username) {
            alert("Email may not be blank");
            return;
        }
        if (!password) {
            alert("Password may not be blank");
            return;
        }
        let response = await postLogin(username, password);
        if (response && response.EC === 0) {
            alert("Login success");
        } else if (response && response.EC !== 0) {
            alert(response.EM);
        }
    };

    // Handle keydown event for Enter key to submit form
    const handleKeyDown = (event) => {
        if (event.key === 'Enter') {
            handleLogin();
        }
    };

    return (
        <>
            <div className="login-container mt-3 mb-5 d-grid gap-2">
                <div className="title fs-1 fw-bold col-4 mx-auto text-center">
                    Simple Login
                </div>
                <div className="welcome col-4 mx-auto text-center">
                    Hello, who’s this?
                </div>
                <div className="content-form col-3 mx-auto d-grid gap-3">
                    <div className="form-group d-grid gap-2">
                        <label>Email</label>
                        <input
                            type="text"
                            className="form-control"
                            placeholder="example@domain.com"
                            onChange={(event) => setUsername(event.target.value)}
                            onKeyDown={(event) => handleKeyDown(event)}
                            value={username}
                        />
                    </div>
                    <div className="form-group d-grid gap-2">
                        <label>Password</label>
                        <div className="input-group">
                            <input
                                type={showPassword ? "text" : "password"}
                                className="form-control"
                                placeholder="At least 8 characters"
                                onChange={(event) => setPassword(event.target.value)}
                                onKeyDown={(event) => handleKeyDown(event)}
                                value={password}
                            />
                            <button
                                type="button"
                                className="btn btn-outline-secondary"
                                onClick={togglePasswordVisibility}
                                style={{ borderLeft: 'none' }}
                            >
                                {showPassword ? "Hide" : "Show"}
                            </button>
                        </div>
                    </div>
                    <button className="btn btn-dark w-100" onClick={handleLogin}>Log in</button>
                </div>
            </div>
        </>
    );
};

export default Login;
