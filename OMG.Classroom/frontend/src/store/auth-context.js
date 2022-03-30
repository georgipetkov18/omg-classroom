import React, { useEffect, useState } from "react";

export const AuthContext = React.createContext({
  loggedIn: false,
  email: "",
  password: "",
  login: (email, password) => {},
  logout: (email) => {},
});

const AuthContextProvider = (props) => {
  const [loggedIn, setLoggedIn] = useState(false);
  const [emailState, setEmailState] = useState("");
  const [passwordState, setPasswordState] = useState("");

  useEffect(() => {
    const loggedInStorage = localStorage.getItem("loggedIn");

    if (loggedInStorage === "1") {
      setLoggedIn(true);
    }
  }, []);

  const loginHandler = (email, password) => {
    localStorage.setItem("loggedIn", "1");
    setEmailState(email);
    setPasswordState(password);
    setLoggedIn(true);

    localStorage.setItem("email", email);
    localStorage.setItem("password", password);
  };

  const logoutHandler = (email) => {
    setEmailState("");
    setPasswordState("");
    setLoggedIn(false);

    localStorage.removeItem("email");
    localStorage.removeItem("password");
    localStorage.setItem("loggedIn", false);
  };

  return (
    <AuthContext.Provider
      value={{
        loggedIn: loggedIn,
        email: emailState,
        password: passwordState,
        login: loginHandler,
        logout: logoutHandler,
      }}
    >
      {props.children}
    </AuthContext.Provider>
  );
};

export default AuthContextProvider;
