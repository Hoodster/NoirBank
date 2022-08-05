import React from 'react'
import DashboardSection from '../../../../components/dashboard-section/dashboard-section'
import OthersContainer from './components/others-container'

function OthersScene() {
	return(
		<DashboardSection lowHeight={true} title='Others'>
			<OthersContainer/>
		</DashboardSection>
	)
}

export default OthersScene