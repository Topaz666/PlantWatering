import React, { useEffect } from 'react'
import { connect } from 'react-redux'
import { fetchPlants, waterPlant} from '../redux/Plants/plantActions'

const PlantsContainer = ({PlantsData, fetchPlants, waterPlant}) => {
    useEffect(() => {
        fetchPlants()
        const intervalId = setInterval(() => {
            fetchPlants()
        }, 10000)
        return () => clearInterval(intervalId);
    },[fetchPlants])

    return PlantsData.loading ? (
        <h2>Loading</h2>
    ) : PlantsData.error ? (
        <h2>{PlantsData.error}</h2>
    ) : (
        <div className="mt-5">
            <h2>Plant List</h2>
            <div className = "w-50 text-justify mx-auto">
                <table className="table">
                    <thead>
                        <tr>
                        <th scope="col">Id</th>
                        <th scope="col">NextWateringRequired</th>
                        <th scope="col">NextWateringAllowed</th>
                        <th scope="col">NeedWater?</th>
                        <th scope="col">Watering</th>
                        </tr>
                    </thead>
                    <tbody>
                    {PlantsData && PlantsData.plants && PlantsData.plants.map((plant) =>
                        <tr>
                            <th scope="row">{plant.id}</th>
                            <td>{plant.reminder6h}</td>
                            <td>{plant.reminder30s}</td>
                            <td>{plant.requiredWater.toString()}</td>
                            <td><button onClick={() => waterPlant(plant.id)} disabled={!plant.wateringAgain} type="button" className="btn btn-primary">
                                    {!plant.requireWaitWatering && <span>Start</span>}
                                    {plant.requireWaitWatering && <span>Waiting</span>}</button></td>
                        </tr>
                    )}
                    </tbody>
                </table>
            </div>
        </div>
    )
}

const mapStateToProps = state => {
    return {
        PlantsData: state
      }
}

const mapDispatchToProps = dispatch => {
    return {
        fetchPlants: () => dispatch(fetchPlants()),
        waterPlant: id => dispatch(waterPlant(id))
    }
}

export default connect(
    mapStateToProps,
    mapDispatchToProps
  )(PlantsContainer)