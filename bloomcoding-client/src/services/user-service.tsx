import { Users } from "../api/axios";

export interface EditData {
    id: number,
    email: string,
    username: string,
    avatarName: string,
    birthDate: string
}

export interface UserData {
    id : number;
    username : string;
    email : string;
    avatarName: string;
    birthDate: string;
}

export interface PageData {
    pageNumber : number;
    pageSize : number;
}


class UserService {
    update(editData: EditData) {
        return Users.update(editData);
    }

    getUsers(pageData : PageData) {
        return Users.users(pageData);
    }

    countUsers() {
        return Users.countUsers();
    }
}

export default new UserService();