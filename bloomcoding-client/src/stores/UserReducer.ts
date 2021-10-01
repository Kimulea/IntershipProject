const userReducer = (state: any, action: any) => {
    switch (action.type){
        case 'SET_USER':
            return {
                ...state,
                user: action.payload
            }
        case 'DELETE_USER':
            return{
                user: null
            }
    }
}

export default userReducer