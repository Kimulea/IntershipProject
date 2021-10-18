import { Button, Card, CardActions, CardContent, FormControl, Grid, InputLabel, OutlinedInput, Paper, TextField, Typography } from "@mui/material";
import { Box } from "@mui/system";
import { useEffect, useRef, useState } from "react";
import { useForm } from "react-hook-form";
import { useHistory } from "react-router-dom";
import authService from "../services/auth-service";
import courseService from "../services/course-service";
import groupService from "../services/group-service";

const EditGroups = () => {
    const history = useHistory();
    const [role, setRole] = useState<any | undefined>();

    const createRef = useRef<HTMLHeadingElement>(null);

    useEffect(() => {
        setRole(authService.getRole());
    }, []);

    const [id, setId] = useState<any>();
    const [name, setName] = useState("");
    const [info, setinfo] = useState("");
    const [groupData, setGroupData] = useState<any>();

    return (
        <Box>
            {role === "Admin" && (
                 <Box style={{margin:"30px auto"}} display="flex" justifyContent="space-evenly">

                     <Grid>
                        <Box  style={{}}>
                                <Button onClick={() => history.push("/")} color="primary" variant="contained">back</Button>
                        </Box>
                        <Box display="flex">
                        <Card style={{width:"200px", margin:"10px"}}>
                            <CardContent>
                                
                            <TextField
                                onChange={(e: any) => setName(e.target.value)}  
                                value={name}
                                label="name"
                            />

                            <TextField
                                onChange={(e: any) => setinfo(e.target.value)}  
                                value={info}
                                label="info"
                            />
                                
                            </CardContent>
                            <CardActions>
                                <Button onClick={() => {groupService.createGroup({name: name, info: info}); setName(""); setinfo("")}} variant="contained" color="primary"> Create Group</Button>
                            </CardActions>
                        </Card>

                        <Card style={{width:"200px", margin:"10px"}}>
                            <CardContent>

                            <TextField
                                onChange={(e: any) => setId(e.target.value)}  
                                value={id}
                                label="id"
                            />
                                
                            <TextField
                                onChange={(e: any) => setName(e.target.value)}  
                                value={name}
                                label="name"
                            />

                            <TextField
                                onChange={(e: any) => setinfo(e.target.value)}  
                                value={info}
                                label="info"
                            />
                                
                            </CardContent>
                            <CardActions>
                                <Button onClick={() => {groupService.updateGroup(id, {name: name, info: info}); setId(""); setName(""); setinfo("")}} variant="contained" color="primary"> Update Group</Button>
                            </CardActions>
                        </Card>

                        <Card style={{width:"200px", margin:"10px"}}>
                            <CardContent>

                            <TextField
                                onChange={(e: any) => setId(e.target.value)}  
                                value={id}
                                label="id"
                            />
                                
                            </CardContent>
                            <CardActions>
                                <Button onClick={() => {groupService.deleteGroup(id); setId("")}} variant="contained" color="error"> Delete Group</Button>
                            </CardActions>
                        </Card>

                        <Card style={{width:"200px", margin:"10px"}}>
                            <CardContent>
                            <Typography>id: {groupData?.id}</Typography>
                            <Typography>Name: {groupData?.name}</Typography>
                            <Typography>Info: {groupData?.info}</Typography>
                            <TextField
                                onChange={(e: any) => setId(e.target.value)}  
                                value={id}
                                label="id"
                            />
                                
                            </CardContent>
                            <CardActions>
                                <Button onClick={() => {
                                    groupService.getGroup(id).then((response) => {
                                        setGroupData(response);
                                    }); 
                                    setId("")
                                    }} variant="contained" color="primary"> Get Group</Button>
                            </CardActions>
                        </Card>

                        </Box>
                     </Grid>
                 </Box>
            )}
        </Box>
    )
}

export default EditGroups;