import Logo from '../logo/Logo'
import './MainBar.scss'

function MainBar() {
    return (<div className='nb-nav'>
        <Logo/>
        <div>
                <span>Sample Name</span>
                <span>^</span>
        </div>
    </div>)
}

export default MainBar