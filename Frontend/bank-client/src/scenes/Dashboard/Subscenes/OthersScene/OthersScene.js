import DashboardSection from "../../../../components/dashboardsection/DashboardSection"
import Button from "../../../../components/inputs/button/button"
import OthersContainer from "./components/OthersContainer"

function OthersScene() {
    return(
        <DashboardSection lowHeight={true} title='Others'>
            <OthersContainer/>
        </DashboardSection>
    )
}

export default OthersScene