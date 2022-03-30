import { useContext, useState } from "react";
import { AuthContext } from "../store/auth-context";
import classes from "./Login.module.css";

const Login = (props) => {
  const [email, setEmail] = useState("");
  const [password, setPassword] = useState("");
  const authCtx = useContext(AuthContext);

  const submitHandler = (e) => {
    e.preventDefault();
    authCtx.login(email, password);
  };

  const emailHandler = (e) => {
    setEmail(e.target.value);
  };

  const passwordHandler = (e) => {
    setPassword(e.target.value);
  };

  return (
    <div className={classes.login}>
      <form onSubmit={submitHandler}>
        <div className={classes.control}>
          <label htmlFor="email">Email</label>
          <input id="email" onChange={emailHandler} />
        </div>
        <div className={classes.control}>
          <label htmlFor="password">Password</label>
          <input id="password" type="password" onChange={passwordHandler} />
        </div>
        <div className={classes.actions}>
          <button type="submit">Submit</button>
        </div>
      </form>
    </div>
  );
};

export default Login;
