import { useState } from "react";
import AdminPanel from "../components/AdminPanel";
import EditGroups from "../components/EditGroups";
import Profile from "../components/Profile";
import Welcome from "../components/Welcome";

const routes = [
    {
        path: '/editGroups',
        component: EditGroups,
        isPrivate:true
    },
    {
        path: '/adminPanel',
        component: AdminPanel,
        isPrivate:true
    },
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