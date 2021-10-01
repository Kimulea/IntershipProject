import { Avatar, Box, FormControl, FormHelperText, Grid, InputLabel, OutlinedInput, Paper, Typography } from "@mui/material";
import LockIcon from '@mui/icons-material/Lock';
import { useForm } from "react-hook-form";
import { useContext, useState } from "react";
import { Context } from "../stores/UserStore";
import { useHistory } from "react-router-dom";
import authService from "../services/auth-service";

interface FormInputs{
  username: string;
  password: string;
}

const Login = () => {
    const paperStyle={padding: 20, height: '70vh', width: '300px', margin:'-40px 60px'};
    const avatarStyle={margin:'0 auto', backgroundColor:'green'};

    const {
      register,
      handleSubmit,
      formState: { errors },
    } = useForm();

    const [userState, dispatch] = useContext(Context)
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
                      if(error.response?.data.errors.message) {
                        setLoginError(true);
                      }
                    });
                })}
              >

                <FormControl variant="outlined" required={true} style={{margin:'-px 0px'}}>
                  <InputLabel htmlFor="component-outlined">username</InputLabel>
                  <OutlinedInput
                    {...register("username", {
                      required: {value: true, message: "username is required"},
                      pattern: {
                        value:
                          /^[a-zA-Z0-9.!#$%&’*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$/,
                        message: "Invalid username address",
                      },
                    })}
                    type="username"
                    id="username"
                    label="username"
                  />
                  <div>{errors.username?.required.message}</div>
                  {loginError && (
                    <FormHelperText error id="username-error-text">
                      Wrong login info
                    </FormHelperText>
                  )}
                </FormControl>
                
              </form>
            </Grid>
        </Box>
    )
}

export default Login;