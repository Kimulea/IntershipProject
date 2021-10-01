import { Avatar, Box, Grid, Paper, Typography } from "@mui/material";
import AccessibilityNewIcon from '@mui/icons-material/AccessibilityNew';

const Register = () => {
    const paperStyle={padding: 20, height: '70vh', width: '300px', margin:'-40px 60px'};
    const avatarStyle={margin:'0 auto', backgroundColor:'green'}

    return(
        <Box>
            <Grid>
              <Paper elevation={10} style={paperStyle}>
                <Grid display="grid" justifyContent="center" style={{margin:'30px 0'}}>
                    <Avatar style={avatarStyle}><AccessibilityNewIcon/></Avatar>
                    <Typography variant="h5">Sign Up</Typography>
                </Grid>
              </Paper>
              {/* {logging ? <Login /> : <Register />} */}
            </Grid>
        </Box>
    )
}

export default Register;