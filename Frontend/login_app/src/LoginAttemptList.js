import React, { useEffect, useState } from "react";
import "./LoginAttemptList.css";

const LoginAttempt = ({ children }) => <li>{children}</li>;

const LoginAttemptList = ({ attempts }) => {
  const [searchTerm, setSearchTerm] = useState("");
  const [filteredAttempts, setFilteredAttempts] = useState(attempts.filter(
    (attempt) =>
      attempt.login.toLowerCase().includes(searchTerm.toLowerCase()) ||
      attempt.password.toLowerCase().includes(searchTerm.toLowerCase())
  ));

  return (
    <div className="Attempt-List-Main">
      <h2>Recent Activity</h2>
      <input
        type="text"
        placeholder="Search..."
        value={searchTerm}
        onChange={(e) =>{
			setSearchTerm(e.target.value)
			setFilteredAttempts(attempts.filter(
				(attempt) =>
				  attempt.login.toLowerCase().includes(e.target.value.toLowerCase()) ||
				  attempt.password.toLowerCase().includes(e.target.value.toLowerCase())
			))
		}}
      />
      <ul className="Attempt-List">
        {filteredAttempts.map((attempt, index) => (
          <LoginAttempt key={index}>
            {attempt.login} - {attempt.password}
          </LoginAttempt>
        ))}
      </ul>
    </div>
  );
};

export default LoginAttemptList;