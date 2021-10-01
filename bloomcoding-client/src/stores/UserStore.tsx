import React, {createContext, useReducer} from "react";
import Reducer from './UserReducer'


const initialState: null | any = {
    user : null
};

export const Context = createContext(initialState);

const Store = ({children}: any) => {
    const [state, dispatch] = useReducer(Reducer, initialState);
    return (
        <Context.Provider value={[state, dispatch]}>
            {children}
        </Context.Provider>
    )
};
export default Store;