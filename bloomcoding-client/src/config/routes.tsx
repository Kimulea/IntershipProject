import Profile from "../components/Profile";
import Welcome from "../components/Welcome";

const routes = [
    {
        path: '/profile',
        component: Profile,
        isPrivate:true
    },
    {
        path: '/',
        component: Welcome,
        isPrivate:false
    }
];

export default routes;