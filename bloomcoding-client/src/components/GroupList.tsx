import { Button, Card, CardActions, CardContent, Grid, Paper, TablePagination, TextField, Typography } from "@mui/material";
import { Box } from "@mui/system";
import { useEffect, useState, MouseEvent, ChangeEvent, useContext} from "react";
import authService from "../services/auth-service";
import GroupService, {PageData} from "../services/group-service";
import ProfileContext from "../context/profile-context";
import { DataGrid, GridApi, GridCellValue, GridColDef, GridRowsProp } from "@mui/x-data-grid";
import courseService from "../services/course-service";

const GroupList = () => {
    const [data, setData] = useState([]);
    const [page, setPage] = useState(0);
    const [rowsPerPage, setRowsPerPage] = useState(5);
    const [detail, setDetail] = useState<number>(0);
    const [groupDetail, setGroupDetail] = useState<any | null>(null);

    const [rows, setRows] = useState<GridRowsProp>([]);
    const [page1, setPage1] = useState(0);
    const [pageSize1, setPageSize1] = useState(5);
    const [countCourses, setcountCourses] = useState<number>(0);

    const [totalPages, setTotalPages] = useState(0);

    const [name, setName] = useState("");
    const [role, setRole] = useState<any | undefined>();

    useEffect(() => {
        setRole(authService.getRole());
    }, []);

    const columns: GridColDef[] = [
        { field: 'col1', headerName: 'name', width: 150 },
        {
            field: "col2",
            headerName: "Action",
            sortable: false,
            renderCell: (params) => {
              const onClick = (e) => {
                e.stopPropagation(); // don't select this row after clicking
        
                const api: GridApi = params.api;
                const thisRow: Record<string, GridCellValue> = {};
        
                api
                  .getAllColumns()
                  .filter((c) => c.field !== "__check__" && !!c)
                  .forEach(
                    (c) => (thisRow[c.field] = params.getValue(params.id, c.field))
                  );
        
                return alert(JSON.stringify(thisRow, null, 4));
              };
        
              return <>{role === "Teacher" && (
                <Button onClick={() => courseService.deleteCourse(params.id)} variant="contained" color="error">Delete</Button>
              )}
              </>;
            }
          },
      ];

    useEffect(() => {

        if(detail !== 0) {
            courseService.countCourses(detail).then((response) => {
                setcountCourses(response);
            })
        }
    }, [detail]);

    useEffect(() => {
        if(detail !== 0 ) {
            courseService.getCourses(detail, {pageNumber: page1, pageSize: pageSize1}).then((response) => {
                
                setRows(response?.map(x => ({id : x.id, col1: x.name, col2: <Box>hello</Box>})));
            });
        }
    });

    useEffect(() => {
        
        if(detail !== 0)
        {
            GroupService.getGroup(detail).then((response) => {
                setGroupDetail(response);
            })
        }

    }, [detail])

    const handleChangePage = (
        event: MouseEvent<HTMLButtonElement> | null,
        newPage: number,
    ) => {
        setPage(newPage);
    };

    const handleChangeRowsPerPage = (
        event: ChangeEvent<HTMLInputElement | HTMLTextAreaElement>,
    ) => {
        setRowsPerPage(parseInt(event.target.value, 10));
        setPage(0);
    };

    const getGroups = (pageData : PageData) => {
        GroupService.getUserGroups(authService.getCurrentUserId(), pageData).then((response) =>{
            setData(response);
        })
    }

    useEffect(() => {
        
        getGroups({pageNumber: page, pageSize: rowsPerPage})
        
        GroupService.countUserGroups(authService.getCurrentUserId()).then((response) =>{
            setTotalPages(response);
        })
    })

    var groups = data.map((group: any) => {
        return (
            <Box key={group.id} display="flex" flexDirection="row">
                <Grid>
                    <Card style={{width:"200px", margin:"10px"}}>
                        <CardContent>
                            <Typography sx={{ fontSize: 14 }} color="text.secondary" gutterBottom>
                                {group.id}
                            </Typography>
                            <Typography variant="h5" component="div">
                            {group.name}
                            </Typography>
                            <Typography variant="body2">
                            {group.info}
                            </Typography>
                        </CardContent>
                        <CardActions>
                            <Button size="small" onClick={() => {setDetail(group?.id)}}>Join</Button>
                        </CardActions>
                    </Card>
                </Grid>
            </Box>
        );
    });

    return(
        <>
            {detail !== 0 ? 
            <Grid>
                <Paper style={{width:"80%", margin:"0 auto"}}>
                    <Grid display="flex">
                        <Grid style={{border:"4px double black", width:"200px"}}>
                            <Button onClick={() => {setDetail(0)}}>Back</Button>
                            <Typography variant="h4" style={{margin:"30px"}}>{groupDetail?.name}</Typography>
                            <Box style={{width:"200px"}}>Details: {groupDetail?.info}</Box>
                        </Grid>

                        <Grid display="flex">
                            {role === "Teacher" && (
                                <Card style={{width:"200px", margin:"10px"}}>
                                <CardContent>
                                    
                                <TextField
                                    onChange={(e: any) => setName(e.target.value)}  
                                    value={name}
                                    label="name"
                                />
                                    
                                </CardContent>
                                <CardActions>
                                    <Button onClick={() => {courseService.createCourse({id: groupDetail.id, name: name}); setName("");}} variant="contained" color="primary"> Create Course</Button>
                                </CardActions>
                                </Card>
                            )}
                            
                        </Grid>
                    </Grid>

                    <Grid style={{height:"400px"}}>
                        <DataGrid 
                            rows={rows}
                            columns={columns}
                            pagination
                            pageSize={pageSize1}
                            onPageSizeChange={(newPageSize) => setPageSize1(newPageSize)}
                            rowsPerPageOptions={[5, 10, 15, 20]}
                            rowCount={countCourses}
                            paginationMode="server"
                            onPageChange={(newPage) => setPage1(newPage)}
                        />
                    </Grid>

                    <Grid></Grid>
                </Paper>
            </Grid> : (
                <Grid>
                    <Box display="flex" justifyContent="center">
                        {groups}
                    </Box>

                    <Box display="flex" justifyContent="center" style={{margin:"20px 0px"}}>
                        <TablePagination
                            component="div"
                            count={totalPages}
                            page={page}
                            onPageChange={handleChangePage}
                            rowsPerPage={rowsPerPage}
                            rowsPerPageOptions={[5]}
                            onRowsPerPageChange={handleChangeRowsPerPage}
                        />
                    </Box>
                </Grid>
            )}
        </>
    )
}

export default GroupList;