import { applyMiddleware, createStore } from 'redux'
import plantReducer from '../Plants/plantReducer'
import logger from 'redux-logger'
import thunk from 'redux-thunk'

const store = createStore(
    plantReducer,
    applyMiddleware(logger,thunk)
    )

export default store