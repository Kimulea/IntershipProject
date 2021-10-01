import { Redirect, Route } from "react-router-dom";
import authService from "../services/auth-service";
 


const AppRoutes = ({ component: Component, path, isPrivate, ...rest } : {component: any, path: string, isPrivate: boolean}) => {
 
    const userDetails = authService.getCurrentUser()
    var x = false;
    
    if( userDetails && userDetails !== "null" && userDetails !== "undefined" )
    {
        x = !Boolean(userDetails.token)
    }
    else
    {
        x = true;
    }

    console.log(isPrivate, "private");
    return (
        <Route
            exact
            path={path}
            render={props =>
                isPrivate && x ? (
                    <Redirect
                        to={{ pathname: "/" }}
                    />
                ) : (
                        <Component {...props} />
                    )
            }
        />
    )
}
 
export default AppRoutes