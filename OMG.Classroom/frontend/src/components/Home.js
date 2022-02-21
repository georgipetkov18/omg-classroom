import React from "react";

import classes from "./Home.module.css";
import Navigation from "./Navigation";

const Home = (props) => {
  return (
    <div className={classes.home}>
      <h1>Welcome back!</h1>
    </div>
  );
};

export default Home;
