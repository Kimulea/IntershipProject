import axios from "axios";
import authService from "../services/auth-service";

axios.defaults.baseURL = "https://localhost:44340/api";

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
    delete: (url: string) => axios.delete(url).then(responseBody),
};

const Users = {
    register: (body: {username: string, email: string, password: string}) => request.post("user/register", body),
    login: (body: {username: string, password: string}) => request.post("user/login", body),
}

export {Users};