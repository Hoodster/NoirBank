import Button from "../../../../../components/inputs/button/button";
import './OthersContainer.scss';

function OthersContainer(props) {
    return <div className="othersContainer">
        <Button type='main' text="Payment history"></Button>
        <Button type='main' text="Make a transfer"></Button>
    </div>
}

export default OthersContainer