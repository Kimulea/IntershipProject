import {Courses} from "../api/axios"

export interface PageData {
    pageNumber : number;
    pageSize : number;
}

export interface CourseDto {
    id: number;
    name: string;
}

class AuthService {
  getCourses(id: number, pageData : PageData) {
      return Courses.courses(id, pageData);
  }

  countCourses(id: number) {
      return Courses.count(id);
  }

  createCourse(courseDto: CourseDto) {
      return Courses.create(courseDto);
  }

  deleteCourse(id: any) {
    return Courses.delete(id);
  }
}

export default new AuthService();
