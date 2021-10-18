import axios from "axios";
import authService from "../services/auth-service";

axios.defaults.baseURL = "https://localhost:5001/api";

axios.interceptors.response.use(undefined, (error) => {
    if (error.message === "Network Error" && !error.response){
        throw error;
    }
    if(error.response.status === 401) {
        authService.logout();
    }
    throw error;
});

axios.interceptors.request.use(
    (config) => {
        const user = authService.getCurrentUser();
        if (user) config.headers.Authorization = `Bearer ${user.token}`
        return config;
    },
    (err) => Promise.reject(err)
);

const responseBody = (response: any) => {
    return response ? response.data: null;
};

const request = {
    get: (url: string) => axios.get(url).then(responseBody),
    post: (url: string, body: object) => axios.post(url, body).then(responseBody),
    put: (url: string, body: object) => axios.put(url, body).then(responseBody),
    delete: (url: string) => axios.delete(url).then(responseBody),
};

const Users = {
    register: (body: {username: string, email: string, password: string}) => request.post("user/register", body),
    login: (body: {username: string, password: string}) => request.post("user/login", body),
    details: (id: number) => request.get(`user/${id}`),
    update: (body: {id: number, email: string, username: string, avatarName: string, birthDate: string}) => request.put("user/update", body),
    users: (body: {pageNumber: number, pageSize: number}) => request.post("user/users", body),
    countUsers: () => request.get("user/countAll")
}

const Groups = {
    userGroups: (id : number, body: {pageNumber: number, pageSize: number}) => request.post(`Group/UserGroups/${id}`, body),
    countUserGroups:(id : number) => request.get(`Group/CountUserGroups/${id}`),
    groups: (body: {pageNumber: number, pageSize: number}) => request.post("Group/getAll", body),
    countGroups: () => request.get("Group/countAll"),
    group: (id : number) => request.get(`Group/${id}`),
    create: (body: {name : string, info: string}) => request.post("Group/CreateGroup", body),
    update: (id: number, body: {name : string, info: string}) => request.put(`Group/${id}`, body),
    delete: (id : number) => request.delete(`Group/${id}`),
}

const Courses = {
    create: (body: {id: number, name : string}) => request.post("Course/create", body),
    delete: (id : number) => request.delete(`Course/delete/${id}`),
    courses: (id: number, body: {pageNumber: number, pageSize: number}) => request.post(`Course/list/${id}`, body),
    count: (id: number) => request.get(`Course/count/${id}`)
}

const UserGroups = {
    createUserGroups: (body:{userId: number, groupId: number}) => request.post("UserGroup/AddUserToGroup", body),
}

const Files = {
    getFile: (name: string) => request.get(`File/get/${name}`)
}

export {Users, Files, Groups, UserGroups, Courses};