import React, { useState } from "react";
import CoursesItem from "./CourseItem";
import Card from "../../UI/Card";

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
      name: "Toshka",
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
        <CoursesItem
          name={x.name}
          teacher={x.teacher}
          students={x.students}
          assignments={x.assignments}
        />
      ))}
    </ul>
  );

  return <Card>{courseList}</Card>;
};

export default Courses;
