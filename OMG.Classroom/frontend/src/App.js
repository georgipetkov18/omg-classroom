import logo from "./logo.svg";
import "./App.css";
import AuthContextProvider, { AuthContext } from "./store/auth-context";
import { useContext } from "react";
import { BrowserRouter, Route, Routes } from "react-router-dom";
import RegisterPage from "./components/pages/Register";
import { useState } from "react";
import Courses from "./components/pages/Courses/Courses";

import Home from "./components/Home";
import Login from "./components/Login";
import Header from "./components/Header";

function App() {
  const authCtx = useContext(AuthContext);

  console.log("app.js hit");
  console.log(authCtx.loggedIn);

  const [users, setUsers] = useState([]);

  const onUserAdded = (user) => {
    setUsers((prevUsers) => {
      prevUsers.push(user);
      return prevUsers;
    });
  };

  return (
    <>
      <Header />
      
      {authCtx.loggedIn && <Home />}
      {!authCtx.loggedIn && <Login />}

      {/* //<BrowserRouter>
      //<Routes>
      //<Route path='/register' element={<RegisterPage onSubmit={onUserAdded} />} />
      //</Routes>
      //</BrowserRouter> */}
    <Courses />
    </>
  )}
export default App;
