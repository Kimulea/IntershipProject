import {Users} from  "../api/axios";

interface LoginData {
  username: string;
  password: string;
}

export interface RegisterData {
  email: string;
  username: string;
  password: string;
}


class AuthService {
  login(userData: LoginData) {
    return Users.login(userData).then((response) => {
      if (response.token) {
        localStorage.setItem("user", JSON.stringify(response));
      }
    });
  }

  logout() {
    localStorage.removeItem("user");
  }

  register(userData: RegisterData) {
    return Users.register(userData);
  }

  getCurrentUser() {
    return JSON.parse(localStorage.getItem("user")!);
  }

  getCurrentUserId() {
    return JSON.parse(localStorage.getItem("user")!).id;
  }

  getRole() {
    return JSON.parse(localStorage.getItem("user")!).role;
  }
}

export default new AuthService();
