import axios from 'axios'

const getOptions = () => {
	const headers = {
		Authorization: `Bearer ${localStorage.getItem('token')}`,
		'Content-Type': 'application/json'
	}

	return {
		headers
	}
}

export const put = (url, data, isAnonymous = false) => {
	const options = getOptions()
	return axios.put(url, data, !isAnonymous ? options : null).catch((error) => {
		if (error.response.status === 401) {
			localStorage.removeItem('token')
			location.reload()
		}
		throw error
	})
}

export const post = (url, data, isAnonymous = false) => {
	const options = getOptions()
	return axios.post(url, data, !isAnonymous ? options : null).catch((error) => {
		if (error.response.status === 401) {
			localStorage.removeItem('token')
			location.reload()
		}
		throw error
	})
}

export const get = (url, isAnonymous = false) => {
	const options = getOptions()
	return axios.get(url, !isAnonymous ? options : null).catch((error) => {
		if (error.response.status === 500 || error.response.status === 401) {
			localStorage.removeItem('token')
			location.reload()
		}
		throw error
	})
}