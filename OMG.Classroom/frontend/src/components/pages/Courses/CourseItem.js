import React from "react";

const CoursesItem = (props) => {
  return (
    <li>
      <div>{props.name}</div>
      <div>{props.teacher.name}</div>
    </li>
  );
};

export default CoursesItem;
