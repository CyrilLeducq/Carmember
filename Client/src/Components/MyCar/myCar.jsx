import "../MyCar/myCar.css"
import CarSelect from "../CarSelect/carSelect"
function MyCar() {
    return ( 
        <div className="myCar-contenant">
            <div className="myCar-title">Mon véhicule</div>
            <div className="car-component">
                <CarSelect/>
            </div>
        </div>
     );
}

export default MyCar;