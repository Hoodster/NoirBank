import axios from 'axios'

const getOptions = () => {
	const headers = {
		Authorization: `Bearer ${localStorage.getItem('token')}`
	}

	return {
		headers
	}
}

export const post = (url, data, isAnonymous = false) => {
	return axios.post(url, data, !isAnonymous ? getOptions : null)
}

export const get = (url, isAnonymous = false) => {
	const options = getOptions()
	return axios.get(url, !isAnonymous ? options : null)
}