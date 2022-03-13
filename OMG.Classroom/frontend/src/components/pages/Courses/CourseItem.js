import React from "react";

import classes from "./CourseItem.module.css";

const CourseItem = (props) => {
  return (
    <li className={classes.course}>
      <div>
        <h3>{props.name}</h3>
        <div className={classes.description}>
          Taught by {props.teacher.name}
        </div>
      </div>
      <div>
        <button type="button" className="btn btn-success">
          Enter course
        </button>
      </div>
    </li>
  );
};

export default CourseItem;
