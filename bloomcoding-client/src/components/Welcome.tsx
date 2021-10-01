import { Box, Button, Grid, Typography } from "@mui/material";
import { useState } from "react";
import { useHistory } from "react-router";
import authService from "../services/auth-service";
import Login from "./Login";
import Register from "./Register";
import BackgoundImg from "../images/background-trend.jpg";
import GroupImg from "../images/group.png";
import BloomImg from "../images/Bloom-logo.png";

const Welcome = () => {
    const bgImage={backgroundImage:`url(${BackgoundImg})`};

    const [logging, setLogging] = useState(true);

    const history = useHistory();

    if(authService.getCurrentUser())
    {
        history.push('/profile');
    }

    return(
        <Box display="flex" style={bgImage}>
            <Grid style={{margin:'70px 0'}}>
              <Box display="flex" justifyContent="space-evenly" style={{borderBottom:'1'}}>
                <Button
                  color={logging ? "primary" : "inherit"}
                  onClick={() => setLogging(true)}
                >
                  Sign in
                </Button>
                <Button
                  color={logging ? "inherit" : "primary"}
                  onClick={() => setLogging(false)}
                >
                  Sign Up
                </Button>
              </Box>
              {logging ? <Login /> : <Register />}
            </Grid>

            <Box sx={{margin:'40px 80px'}}>
                <img src={BloomImg} alt="desc" width='15%'/>
                <Typography variant="h6">Pentru copii de 7-14 ani</Typography>
                <Typography variant="h4">Scoala digitala de programare si logica</Typography>
                <img src={GroupImg} alt="desc" width='90%'/>
            </Box>
        </Box>


    )
}

export default Welcome;