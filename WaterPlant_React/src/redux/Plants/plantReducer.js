import {
    FETCH_PLANTS_REQUEST, 
    FETCH_PLANTS_SUCCESS, 
    FETCH_PLANTS_FAILURE,
    WATER_PLANT_POST,
} from './plantTypes'

const initialState = {
    plants: [],
    loading: false,
    error: ''
}

const plantReducer = (state = initialState, action) =>{
    switch (action.type){
        case FETCH_PLANTS_REQUEST:
            return {
                ...state,
            }
        case FETCH_PLANTS_SUCCESS:
            return {
                loading: false,
                plants: action.payload,
                error: ''
            }
        case FETCH_PLANTS_FAILURE:
            return {
                loading: false,
                plants: [],
                error: action.payload
            }
        case WATER_PLANT_POST:
            return {
                loading: false,
                plants: action.payload,
                error: ''
            }
        default:
            return state;
    }
}
export default plantReducer;
