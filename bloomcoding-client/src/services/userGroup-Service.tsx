import { UserGroups } from "../api/axios";

export interface UserGroupData {
    userId : number;
    groupId : number
}

class UserService {
    CreateRelation(userGroup : UserGroupData) {
        return UserGroups.createUserGroups(userGroup);
    }
    
}

export default new UserService();