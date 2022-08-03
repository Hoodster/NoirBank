import MainBar from '../../components/mainbar/MainBar'
import AccountsScene from './Subscenes/AccountsScene'
import CardsScene from './Subscenes/CardsScene/CardsScene'
import OthersScene from './Subscenes/OthersScene/OthersScene'

import './DashboardScene.css'
function DashboardScene() {
    return (<div className='nb-dash'>
        <MainBar />
        <CardsScene/>
        <AccountsScene/>
        <OthersScene/>
    </div>)
}

export default DashboardScene