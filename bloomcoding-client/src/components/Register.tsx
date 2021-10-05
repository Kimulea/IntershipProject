import { Avatar, Box, Button, Collapse, FormControl, FormHelperText, Grid, InputLabel, OutlinedInput, Paper, Typography } from "@mui/material";
import AccessibilityNewIcon from '@mui/icons-material/AccessibilityNew';
import { useState } from "react";
import AuthService, { RegisterData } from "../services/auth-service";
import { useForm } from "react-hook-form";

const Register = () => {
    const paperStyle={padding: 20, height: '500px', width: '300px', margin:'-40px 60px'};
    const avatarStyle={margin:'0 auto', backgroundColor:'green'}

    const [, setUsedUsername] = useState<boolean>(false);
    const [loading, setLoading] = useState(false);
    const [successMessage, setSuccessMessage] = useState(false);
    const [errorReg, setErrorReg] = useState<boolean>(false);

    const submitRegisterForm = (formData: RegisterData) => {
        setLoading(true);
        setUsedUsername(false);
        AuthService.register(formData)
          .then(() => {
            setLoading(false);
            setSuccessMessage(true);
          })
          .catch((error) => {
            setLoading(false);
            if(error?.response) {
              setErrorReg(true);
            }
          });
      };

      const {
        register,
        handleSubmit,
        formState: { errors },
      } = useForm();

    return(
        <Box>
            <Grid>
              <Paper elevation={10} style={paperStyle}>
                <Grid display="grid" justifyContent="center" style={{margin:'30px 0'}}>
                    <Avatar style={avatarStyle}><AccessibilityNewIcon/></Avatar>
                    <Typography variant="h5">Sign Up</Typography>
                </Grid>
              </Paper>
              
              <form
                onSubmit={handleSubmit(submitRegisterForm)}
              >
                
                <Box style={{margin:'-350px 120px'}}>
                  <FormHelperText error>{errors?.message}</FormHelperText>

                  <FormControl variant="outlined" required={true}>
                    <InputLabel htmlFor="component-outlined">Username</InputLabel>
                    <OutlinedInput
                      {...register("username", {
                        required: true,
                        minLength: {
                          value: 3,
                          message: "username should be at least 3 chars long.",
                        },
                      })}
                      id="username"
                      label="username"
                    />
                  </FormControl>

                  <FormControl variant="outlined" required={true} style={{marginTop:'20px'}}>
                    <InputLabel htmlFor="component-outlined">Email</InputLabel>
                    <OutlinedInput
                      {...register("email", {
                        required: true,
                        pattern: {
                          value:
                            /^[a-zA-Z0-9.!#$%&’*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$/,
                          message: "Invalid email address",
                        },
                      })}
                      type="email"
                      id="email"
                      label="Email"
                    />
                  </FormControl>

                  <FormControl error={errors.password} variant="outlined" required={true} style={{marginTop:'20px'}}>
                    <InputLabel htmlFor="component-outlined">Password</InputLabel>
                    <OutlinedInput
                      error={errors.password}
                      {...register("password", {
                        required: true,
                        pattern: {
                          value: /^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{8,}$/,
                          message:
                            "Password should be at least 8 characters long and containt a digit.",
                        },
                      })}
                      type="password"
                      id="password"
                      label="Password"
                    />
                  </FormControl>

                  {errorReg && (
                      <FormHelperText error id="pass-error-text">
                        Wrong register info
                      </FormHelperText>
                    )}

                  <Box display="grid" justifyContent="center">
                    <Button
                      style={{marginTop:'20px'}}
                      type="submit"
                      variant="contained"
                      color="primary"
                      disabled={loading}
                    >
                      Submit
                    </Button>
                  </Box>

                  {successMessage && (
                  <Collapse in={successMessage}>
                  <Box display="flex" justifyContent="center" flexDirection="row">
                    <Typography variant="h5" color="Primary">Success! Now you can log in!</Typography>
                  </Box>
                  </Collapse>
                )}

                </Box>

              </form>

            </Grid>
        </Box>
    )
}

export default Register;