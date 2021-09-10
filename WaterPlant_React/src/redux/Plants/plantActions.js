import axios from 'axios'
import {
        FETCH_PLANTS_REQUEST, 
        FETCH_PLANTS_SUCCESS, 
        FETCH_PLANTS_FAILURE,
        WATER_PLANT_POST,
} from './plantTypes'

export const fetchPlants = () => {
    return async (dispatch) => {
        dispatch(fetchPlantsRequest())
        await axios
            .get('http://localhost:5000/api/plant/getplants')
            .then(response => {
                const plants = response.data
                dispatch(fetchPlantsSuccess(plants))
            })
            .catch(error => {
                dispatch(fetchPlantsFailure(error.message))
            })
    }
}

export const waterPlant = (id)=> {
  return async (dispatch) => {
      let url = "http://localhost:5000/api/plant/" + id + "/updateplant"
      let data = {id}
      await axios
          .post(url,data)
          .then(response => {
              const plants = response.data
              dispatch(waterPlantPost(plants))
              setTimeout(() => {
                dispatch(fetchPlantsSuccess(plants))
              }, 2000);
          })
          .catch(error => {
              dispatch(fetchPlantsFailure(error.message))
          })
  }
}

export const fetchPlantsRequest = () => {
    return {
      type: FETCH_PLANTS_REQUEST
    }
  }
  
export const fetchPlantsSuccess = plants => {
    return {
      type: FETCH_PLANTS_SUCCESS,
      payload: plants
    }
  }
  
export const fetchPlantsFailure = error => {
    return {
      type: FETCH_PLANTS_FAILURE,
      payload: error
    }
  }

export const waterPlantPost = plants => {
    return {
        type: WATER_PLANT_POST,
        payload: plants
    }
}

