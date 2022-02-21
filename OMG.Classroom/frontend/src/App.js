import logo from "./logo.svg";
import "./App.css";
import AuthContextProvider, { AuthContext } from "./store/auth-context";
import { useContext } from "react";

import Home from "./components/Home";
import Login from "./components/Login";
import Header from "./components/Header";

function App() {
  const authCtx = useContext(AuthContext);

  console.log("app.js hit");
  console.log(authCtx.loggedIn);

  return (
    <>
      <Header />
      {authCtx.loggedIn && <Home />}
      {!authCtx.loggedIn && <Login />}
    </>
  );
}

export default App;
