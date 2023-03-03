import React, { useState } from "react";
import "./LoginForm.css";

const LoginForm = ({ onSubmit }) => {
  const [login, setLogin] = useState("");
  const [password, setPassword] = useState("");

  const handleSubmit = (e) => {
	console.log("Submit clicked");
    e.preventDefault();
    onSubmit({ login, password });
    setLogin("");
    setPassword("");
  };

  return (
    <form className="form" onSubmit={handleSubmit}>
      <h2>Login</h2>
      <label>
        Username:
        <input
          type="text"
          value={login}
          onChange={(e) => setLogin(e.target.value)}
        />
      </label>
      <label>
        Password:
        <input
          type="password"
          value={password}
          onChange={(e) => setPassword(e.target.value)}
        />
      </label>
      <button type="submit">Submit</button>
    </form>
  );
};

export default LoginForm;