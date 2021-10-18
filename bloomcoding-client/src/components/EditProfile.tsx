import { Button, FormControl, FormHelperText, Grid, InputLabel, OutlinedInput, Paper, Stack, TextField } from "@mui/material";
import { Box } from "@mui/system";
import { useEffect, useState } from "react";
import { useForm } from "react-hook-form";
import { useHistory } from "react-router";
import { Users } from "../api/axios";
import UserService, { EditData } from "../services/user-service";
import AuthService from "../services/auth-service";

const EditProfile = () => {
    
    const [userData, setUserData] = useState<any | null>();
    const [errorReg, setErrorReg] = useState(false);

    const history = useHistory();

    useEffect(() => {
        Users.details(AuthService.getCurrentUserId()).then((response) =>
        {
            setUserData(response);
        }
        );
    }, []);

    const submitEditProfileForm = (formData: EditData) => {
        if(formData.username === "")
            formData.username = userData?.username;

        if(formData.email === "")
            formData.email = userData?.email;

        if(formData.avatarName === "")
            formData.avatarName = userData?.avatarName;

        UserService.update(formData)
        .catch((error) => {
            if(error?.response) {
              setErrorReg(true);
            }
          });

        history.push("/");
    }

    const {
        register,
        handleSubmit,
        setValue,
        formState: { errors },
      } = useForm();

    return(
        <Box >
            <Paper elevation={5} style={{width:'50%', height:'300px', margin:'2% auto'}}>
                <form
                    onSubmit={handleSubmit(submitEditProfileForm)}
                >
                    <FormControl variant="outlined" style={{margin:"20px 40%", width:'20%'}}>
                        <InputLabel htmlFor="component-outlined" style={{margin:"-10px 20%"}}>Username</InputLabel>
                        <OutlinedInput
                        {...register("username", {
                            required: false,
                            minLength: {
                            value: 3,
                            message: "username should be at least 3 chars long.",
                            },
                        })}
                        id="username"
                        label="username"
                        />
                    </FormControl>
                    
                    <FormControl variant="outlined" style={{margin:"0px 40%", width:'20%'}}>
                        <InputLabel htmlFor="component-outlined" style={{margin:"-10px 20%"}}>Email</InputLabel>
                        <OutlinedInput
                        {...register("email", {
                            required: false,
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
                        
                    <Box display="grid" justifyContent="center">
                        <Button
                        onClick = {() => {
                            setValue("id", userData?.id);
                        }}
                        style={{marginTop:'20px'}}
                        type="submit"
                        variant="contained"
                        color="primary"
                        >
                            Submit
                        </Button>
                    </Box>
                </form>
            </Paper>
        </Box>
    )
}

export default EditProfile;