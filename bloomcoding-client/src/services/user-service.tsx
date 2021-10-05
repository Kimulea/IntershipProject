import { Users } from "../api/axios";

export interface EditData {
    id: number,
    email: string,
    username: string,
    avatarName: string,
    birthDate: string
}

class UserService {
    update(editData: EditData) {
        return Users.update(editData);
    }
}

export default new UserService();