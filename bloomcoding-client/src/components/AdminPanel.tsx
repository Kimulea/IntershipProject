import { Button, FormControl, Grid, InputLabel, OutlinedInput, Paper, Typography, Box } from "@mui/material";
import { DataGrid, GridColDef, GridRowsProp } from "@mui/x-data-grid";
import { useEffect, useRef, useState } from "react";
import { useForm } from "react-hook-form";
import { useHistory } from "react-router";
import authService from "../services/auth-service";
import groupService from "../services/group-service";
import userService, {UserData, PageData} from "../services/user-service";
import userGroupService, { UserGroupData } from "../services/userGroup-Service";
  
const columnsV: GridColDef[] = [
    { field: 'col1', headerName: 'Id', width: 150 },
    { field: 'col2', headerName: 'username', width: 150 },
    { field: 'col3', headerName: 'email', width: 150 },
  ];

const columnsV1: GridColDef[] = [
    { field: 'col1', headerName: 'Id', width: 150 },
    { field: 'col2', headerName: 'name', width: 150 },
    { field: 'col3', headerName: 'description', width: 150 },
  ];

const AdminPanel = () => {
    const history = useHistory();
    const [role, setRole] = useState<any | undefined>();

    useEffect(() => {
        setRole(authService.getRole());
    }, []);

    const [page, setPage] = useState(0);
    const [pageSize, setPageSize] = useState(10);
    const [page1, setPage1] = useState(0);
    const [pageSize1, setPageSize1] = useState(10);
    const [rows, setRows] = useState<GridRowsProp>([]);
    const [rows1, setRows1] = useState<GridRowsProp>([]);
    const [loading, setLoading] = useState<boolean>(false);
    const [succesAdd, setSuccesAdd] = useState(false);

    const [countUsers, setcountUsers] = useState<number>(0);
    const [countGroups, setcountGroups] = useState<number>(0);

    useEffect(() => {

        groupService.countAll().then((response) => {
            setcountGroups(response);
        })

        userService.countUsers().then((response) => {
            setcountUsers(response);
        })
    });

    useEffect(() => {
        let active = true;

        userService.getUsers({pageNumber: page, pageSize: pageSize}).then((response) => {
            setLoading(true);

            setRows(response?.map(x => ({id : x.id, col1: x.id, col2: x.username, col3: x.email})));

            setLoading(false);
        });
    
        

        return () => {
          active = false;
        };
      }, [page, pageSize]);


    useEffect(() => {
        let active = true;

        groupService.getGroups({pageNumber: page1, pageSize: pageSize1}).then((response) => {
            setLoading(true);

            setRows1(response?.map(x => ({id : x.id, col1: x.id, col2: x.name, col3: x.info})));

            setLoading(false);
        });
    
        

        return () => {
          active = false;
        };
      }, [page1, pageSize1]);

      const {
        register,
        handleSubmit,
        formState: { errors },
      } = useForm();

    return (
        <Box>
            {role === 'Admin' && (
                <Paper elevation={5} style={{width:"100%", height:"600px", margin:"30px auto"}}>
                    
                    <Grid display="flex" style={{width:"100%", height:"100%"}}>
                        <Grid style={{width:"700px", height:"100%"}}>
                            <DataGrid 
                                rows={rows}
                                columns={columnsV}
                                pagination
                                pageSize={pageSize}
                                onPageSizeChange={(newPageSize) => setPageSize(newPageSize)}
                                rowsPerPageOptions={[5, 10, 15, 20]}
                                rowCount={countUsers}
                                paginationMode="server"
                                onPageChange={(newPage) => setPage(newPage)}
                                loading={loading}
                            />
                        </Grid>

                        <Box  style={{}}>
                            <Button onClick={() => history.push("/")} color="primary" variant="contained">back</Button>
                        </Box>

                        <Grid style={{width:"300px"}}>
                            <form
                                onSubmit={handleSubmit((formData: UserGroupData) => {
                                    userGroupService.CreateRelation(formData);
                                    setSuccesAdd(true);
                                  })}
                            >
                                <Box style={{margin:"250px 30px", width:"200px"}}>
                                    
                                    <FormControl variant="outlined" required={true} >
                                        <InputLabel htmlFor="component-outlined">user id</InputLabel>
                                        <OutlinedInput
                                        {...register("userId", {
                                        })}
                                        type="userid"
                                        id="userid"
                                        label="userid"
                                        />

                                    </FormControl>

                                    <FormControl variant="outlined" required={true} >
                                        <InputLabel htmlFor="component-outlined">group id</InputLabel>
                                        <OutlinedInput
                                        {...register("groupId", {
                                        })}
                                        type="groupId"
                                        id="groupId"
                                        label="groupId"
                                        />

                                    </FormControl>

                                    {succesAdd && (
                                        <Typography variant="h5" color="primary">Succes!</Typography>
                                    )}

                                    <Button style={{marginTop:'20px', marginLeft:"60px"}} type="submit" variant="contained" color="primary">
                                        Submit
                                    </Button>
                                </Box>
                            </form>

                            
                        </Grid>

                        <Grid style={{width:"700px ", height:"100%"}}>
                            <DataGrid 
                                rows={rows1}
                                columns={columnsV1}
                                pagination
                                pageSize={pageSize1}
                                onPageSizeChange={(newPageSize) => setPageSize1(newPageSize)}
                                rowsPerPageOptions={[5, 10, 15, 20]}
                                rowCount={countGroups}
                                paginationMode="server"
                                onPageChange={(newPage) => setPage1(newPage)}
                                loading={loading}
                            />
                        </Grid>
                    </Grid>

                </Paper>
            )}

            {role !== 'Admin' && (
                <Paper elevation={5} style={{width:"80%", height:"400px", margin:"30px auto"}}>
                    <Box>
                        <Typography variant="h2" style={{margin:"0 30%", width:'100%'}}> You're not Admin</Typography>
                    </Box>
                </Paper>
            )}
            
        </Box>
    )
}

export default AdminPanel;