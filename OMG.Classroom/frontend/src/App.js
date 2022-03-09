import "./App.css";
import { BrowserRouter, Route, Routes } from "react-router-dom";
import RegisterPage from "./components/pages/Register";
import { useState } from "react";
import Courses from "./components/pages/Courses/Courses";

function App() {
  const [users, setUsers] = useState([]);

  const onUserAdded = (user) => {
    setUsers((prevUsers) => {
      prevUsers.push(user);
      return prevUsers;
    });
  };
  return (
    // <BrowserRouter>
    //   <Routes>
    //     <Route path='/register' element={<RegisterPage onSubmit={onUserAdded} />} />
    //   </Routes>
    // </BrowserRouter>
    <Courses />
  );
}

export default App;
