import { Avatar, Box, Button, Grid, Paper, Typography } from "@mui/material";
import { useContext, useEffect, useState } from "react";
import { useHistory } from "react-router-dom";
import { Users, Files } from "../api/axios";
import authService from "../services/auth-service";
import EditProfile from "./EditProfile";
import GroupList from "./GroupList";
import Login from "./Login";
import ProfileContext from "../context/profile-context";

const Profile = () => {

    const [userData, setUserData] = useState<any | null>();
    const [avatarImg, setAvatarImg] = useState<any | null>();
    const [listTrue, setListTrue] = useState(true);
    const [role, setRole] = useState<any | undefined>();

    const history = useHistory();

    useEffect(() => {
        Users.details(authService.getCurrentUserId()).then((response) =>
          setUserData(response)
        );

        setRole(authService.getRole());
    }, []);

    useEffect(() => {
        Files.getFile(userData?.avatarName).then((response) =>
        
            setAvatarImg(response)
        );

    }, [userData]);

    const logout = () => {
        authService.logout();
        history.push("/");
    };

    return(
        <Box>
            <Grid >
                <Grid>
                    <Paper elevation={5} style={{height:'300px', width:'70%', margin:'2% auto'}}>
                        <Grid display="flex">
                            <Grid style={{padding:'75px 5%'}}>
                                <Avatar sx={{width:'150px', height:'150px'}} alt={userData?.avatarName} src={avatarImg?.file}></Avatar>
                                {/* {avatarImg?.file} */}
                            </Grid>

                            <Grid style={{margin:'100px 2%'}}>
                                <Typography>Username: {userData?.username}</Typography>
                                <Typography>Email: {userData?.email}</Typography>
                                <Typography>Birth Date: {userData?.birdthDate}</Typography>
                                <Typography>Role: {role}</Typography>
                            </Grid>

                            <Grid style={{margin:'100px 5%'}}>
                                <Button onClick={logout} color="error" > Logout</Button>
                                <Button onClick={() => setListTrue(false)} color="primary">Edit profile</Button>
                                {role === 'Admin' && (
                                    <Box>
                                        <Button onClick={() => history.push("/adminPanel")} color="warning">Admin panel</Button>
                                        <Button onClick={() => history.push("/editGroups")} color="warning">Edit Groups</Button>
                                    </Box>
                                )}
                            </Grid>
                        </Grid>
                    </Paper>
                </Grid>

                <Grid>

                    {listTrue ? <GroupList/> : <EditProfile/>}
                </Grid>
            </Grid>
        </Box>
    )
}

export default Profile;