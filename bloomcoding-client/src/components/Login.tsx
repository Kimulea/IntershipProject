import { Avatar, Box, Button, FormControl, FormHelperText, Grid, InputLabel, OutlinedInput, Paper, Typography } from "@mui/material";
import LockIcon from '@mui/icons-material/Lock';
import { useForm } from "react-hook-form";
import { useContext, useState } from "react";
import { Context } from "../stores/UserStore";
import { useHistory } from "react-router-dom";
import authService from "../services/auth-service";

const Login = () => {
    const paperStyle={padding: 20, height: '500px', width: '300px', margin:'-40px 60px'};
    const avatarStyle={margin:'0 auto', backgroundColor:'green'};

    const {
      register,
      handleSubmit,
      formState: { errors },
    } = useForm();

    const [, dispatch] = useContext(Context)
    const history = useHistory();

    const [loginError, setLoginError] = useState<boolean>(false);

    return(
        <Box>
            <Grid>
              <Paper elevation={10} style={paperStyle}>
                <Grid display="grid" justifyContent="center" style={{margin:'30px 0'}}>
                    <Avatar style={avatarStyle}><LockIcon/></Avatar>
                    <Typography variant="h5">Sign In</Typography>
                </Grid>
              </Paper>
              
              <form 
                onSubmit={handleSubmit((formData: any) => {
                  authService.login(formData)
                    .then((status: any) => {
                        history.push("/profile");
                        dispatch({type: 'SET_USER', payload: authService.getCurrentUser()});
                    })
                    .catch((error) => {
                      if(error?.response) {
                        setLoginError(true);
                      }
                    });
                })}
              >
  
                <Box style={{margin:'-350px 120px'}}>
                  <FormControl variant="outlined" required={true} >
                    <InputLabel htmlFor="component-outlined">username</InputLabel>
                    <OutlinedInput
                      {...register("username", {
                        required: {value: true, message: "username is required"},
                        minLength: {
                          value: 3,
                          message: "username should be at least 3 chars long.",
                        },
                      })}
                      type="username"
                      id="username"
                      label="username"
                    />

                  </FormControl>

                  <FormControl variant="outlined" required={true} style={{marginTop:'20px'}}>
                    <InputLabel error={errors.password} htmlFor="password">Password</InputLabel>
                    <OutlinedInput
                      error={errors.password}
                      {...register("password", { required: true, minLength: {value: 8, message: "Password must be at least 8 characters."} })}
                      type="password"
                      id="password"
                      label="Password"
                    />
                    

                    {loginError && (
                      <FormHelperText error id="email-error-text">
                        Wrong login info
                      </FormHelperText>
                    )}
                  </FormControl>

                  <Box display="grid" justifyContent="center">
                  <Button style={{marginTop:'20px'}} type="submit" variant="contained" color="primary">
                    Submit
                  </Button>
                  </Box>
                </Box>
                
              </form>
            </Grid>
        </Box>
    )
}

export default Login;