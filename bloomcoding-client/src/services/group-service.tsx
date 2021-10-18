import { Groups } from "../api/axios";

export interface PageData {
    pageNumber : number;
    pageSize : number;
}

export interface GroupData {
    name : string;
    info: string;
}

class GroupService {
    getUserGroups(id: number, pageData : PageData) {
        return Groups.userGroups(id, pageData);
    }

    countUserGroups(id: number) {
        return Groups.countUserGroups(id);
    }

    getGroups(pageData : PageData) {
        return Groups.groups(pageData);
    }

    countAll() {
        return Groups.countGroups();
    }

    getGroup(id : number) {
        return Groups.group(id);
    }

    createGroup(groupData: GroupData) {
        Groups.create(groupData);
    }

    updateGroup(id: number, groupData: GroupData) {
        Groups.update(id, groupData);
    }

    deleteGroup(id: number) {
        Groups.delete(id);
    }
}

export default new GroupService();