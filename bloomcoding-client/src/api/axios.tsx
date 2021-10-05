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
    getQuery: (url: string, qparams: any) => axios.get(url, {params: {...qparams}}).then(responseBody),
    post: (url: string, body: object) => axios.post(url, body).then(responseBody),
    put: (url: string, body: object) => axios.put(url, body).then(responseBody),
    delete: (url: string, body: object) => axios.delete(url, body).then(responseBody),
};

const Users = {
    register: (body: {username: string, email: string, password: string}) => request.post("user/register", body),
    login: (body: {username: string, password: string}) => request.post("user/login", body),
    details: (id: number) => request.get(`user/${id}`),
    update: (body: {id: number, email: string, username: string, avatarName: string, birthDate: string}) => request.put("user/update", body),
    delete: (body: {id: number}) => request.delete("user/delete", body)
}

const Files = {
    getFile: (name: string) => request.get(`File/get/${name}`)
}

export {Users, Files};