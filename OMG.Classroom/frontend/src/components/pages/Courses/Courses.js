import React, { useState } from "react";
import CourseItem from "./CourseItem";
import Card from "../../UI/Card";

import classes from "./Courses.module.css";

const DUNNY_COURSES = [
  {
    id: 1,
    name: "Maths",
    teacher: {
      name: "Andreeva",
    },
    students: [],
    assignments: [],
  },
  {
    id: 2,
    name: "Software Engineering",
    teacher: {
      name: "Marinov",
    },
    students: [],
    assignments: [],
  },
  {
    id: 3,
    name: "Web Programming",
    teacher: {
      name: "Peev",
    },
    students: [],
    assignments: [],
  },
  {
    id: 4,
    name: "BEL",
    teacher: {
      name: "Tosheva",
    },
    students: [],
    assignments: [],
  },
];

const Courses = (props) => {
  const [courses, setCourses] = useState(DUNNY_COURSES);

  const onCourseAdded = (course) => {
    setCourses((prevCourses) => {
      prevCourses.push(course);
      return prevCourses;
    });
  };

  const courseList = (
    <ul>
      {courses.map((x) => (
        <CourseItem
          key={x.id}
          name={x.name}
          teacher={x.teacher}
          students={x.students}
          assignments={x.assignments}
        />
      ))}
    </ul>
  );

  return (
    <section className={classes.courses}>
      <Card>{courseList}</Card>
    </section>
  );
};

export default Courses;
