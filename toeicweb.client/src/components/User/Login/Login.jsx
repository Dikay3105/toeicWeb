import { useState } from "react";

const Login = () => {
    const [email, setEmail] = useState("");
    const [password, setPassword] = useState("");
    const [showPassword, setShowPassword] = useState(false);

    // Toggle password visibility
    const togglePasswordVisibility = () => {
        setShowPassword(!showPassword);
    };

    // Handle login functionality
    const handleLogin = () => {
        if (!email || !password) {
            alert("Please enter both email and password");
            return;
        }

        // Mock login process
        if (email === "test@example.com" && password === "password123") {
            alert("Logged in successfully!");
            // Navigate to dashboard or homepage after login
        } else {
            alert("Invalid email or password");
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
                            type="email"
                            className="form-control"
                            placeholder="example@domain.com"
                            onChange={(event) => setEmail(event.target.value)}
                            onKeyDown={(event) => handleKeyDown(event)}
                            value={email}
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
